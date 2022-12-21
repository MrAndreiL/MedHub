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

        /*
        public static Response<TEntity> Done(TEntity entity)
        {
            return new Response<TEntity> 
            {
                Entity = entity,
                Result = OperationResult.Done
            };
        }

        public static Response<TEntity> CreateFor(OperationResult result, TEntity entity)
        {
            return new Response<TEntity>
            {
                Entity = entity,
                Result = result
            };
        }

        public static Response<TEntity> CreateFor(OperationResult result, string message, TEntity entity)
        {
            return new Response<TEntity>
            {
                Entity = entity,
                Result = result,
                Message = message
            };
        }
        */
    }
}
