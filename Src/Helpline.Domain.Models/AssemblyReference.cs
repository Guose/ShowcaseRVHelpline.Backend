using System.Reflection;

namespace Helpline.Domain.Models
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
