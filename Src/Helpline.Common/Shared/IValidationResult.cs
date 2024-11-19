namespace Helpline.Common.Shared
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new Error(
            "ValidationError",
            "A validation problem occurred.");

        Error[] Errors { get; }
    }
}
