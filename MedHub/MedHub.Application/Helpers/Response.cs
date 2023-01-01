namespace MedHub.Application.Helpers
{
    public class Response<TEntity>
    {
        public TEntity? Entity { get; private set; }
        public string? Message { get; private set; }
        public OperationState Status { get; private set; }

        private Response() { }

        public static Response<TEntity> Create(OperationState status, string? message = null) 
        {
            return new Response<TEntity> { Status = status, Message = message };
        }

        public static Response<TEntity> Create(OperationState status, TEntity entity, string? message = null)
        {
            return new Response<TEntity> { Status = status, Entity = entity, Message = message };
        }
    }
}
