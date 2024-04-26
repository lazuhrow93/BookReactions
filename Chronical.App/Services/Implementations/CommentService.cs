using AutoMapper;
using Chronical.App.Models.IncomingDto;
using Chronical.App.Models.OutgoingDto;
using Chronical.App.Services.Interfaces;
using Chronicle.Domain.Entity;
using Chronicle.Domain.Repositories;
using Chronicle.Domain.Repositories.Interfaces;

namespace Chronical.App.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private IAuthorRepository _authorRepository;
        private IBookRepository _bookRepository;
        private IChapterRepository _chapterRepository;
        private ICharacterRepository _characterRepository;
        private IMapper _mapper;

        public CommentService(
            ICommentRepository commentRepository,
            IAuthorRepository authorRepository,
            IBookRepository bookRepository,
            IChapterRepository chapterRepository,
            ICharacterRepository characterRepository,
            IMapper mapper)
        {
            _commentRepository = commentRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _chapterRepository = chapterRepository;
            _characterRepository = characterRepository;
            _mapper = mapper;
        }

        public RepositoryResult<List<Comment>> GetAllCharacterComments(int characterId)
        {
            var repoResult = new RepositoryResult<List<Comment>>();
            repoResult.SetState(State.NotFound);

            var characterInBook = _characterRepository.Get(characterId);
            
            if(characterInBook is null)
            {
                repoResult.AddError(string.Format("Unable to find character {0}", characterId));
                return repoResult;
            }

            var characterComments = _commentRepository.Find(c => c.CharacterId == characterInBook.Id);

            repoResult.Entity = characterComments.ToList();

            if (characterComments?.Any() == true) repoResult.SetState(State.Found);
            return repoResult;
        }

        public RepositoryResult<Comment> AddCommentForCharacter(AddCommentDto dto)
        {
            var result = new RepositoryResult<Comment>();
            result.SetState(State.NotAdded);

            var character = _characterRepository.Get(dto.CharacterId);
            if(character is null)
            {
                result.AddError(string.Format("Unable to find that character {0}", dto.CharacterId));
                return result;
                
            }

            var newComment = _mapper.Map<Comment>(dto);
            newComment.BookId = character.BookId;

            var entityEntry = _commentRepository.Add(newComment);
            _commentRepository.SaveChanges();
            result.SetState(State.Added);
            result.Entity = entityEntry.Entity;
            return result;
        }

        public RepositoryResult<BookCommentsDetailsDto> GetAllCommentsForBook(int bookId)
        {
            var result = new RepositoryResult<BookCommentsDetailsDto>();
            result.SetState(State.NotAdded);

            var book = _bookRepository.Get(bookId);
            if(book is null)
            {
                result.AddError(string.Format("Unable to find book {0}", bookId));
                return result;
            }

            var outgoingDto = new BookCommentsDetailsDto();
            outgoingDto = _mapper.Map<BookCommentsDetailsDto>(book);

            var comments = _commentRepository.GetByBook(bookId);
            if(comments?.Any() != true)
            {
                result.Entity = outgoingDto;
                return result;
            }

            //parse comments into dto
            //NEED TO TEST THIS. PARSING INTO THE BIG DTO OF ALL OCMMENTS

            var commentsByCharacterId = comments.ToLookup(c => c.CharacterId);
            var characterIds = commentsByCharacterId.Select(c => c.Key);
            foreach(var characterId in characterIds)
            {
                var character = _characterRepository.Get(characterId);
                outgoingDto.Comments.Add(new CharacterCommentsDto()
                {
                    CharacterId = character!.Id,
                    CharacterName = character.FullName,
                    Comments = _mapper.Map<List<CommentDto>>(commentsByCharacterId[characterId])
                });
            }

            return result;
        }
    }
}
