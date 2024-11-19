using System.Reflection;

namespace Helpline.DataAccess.Models
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }
}
