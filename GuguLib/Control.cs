using System;

namespace GuguLib
{
    /// <summary>
    /// The method could throw exception after it;s execution, so the attribute
    /// signs that it will return
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    internal sealed class ControllableAttribute : Attribute
    {
        public ControllableAttribute() : base()
        {
        }
    }

    /// <summary>
    /// The function type for safeguarding an exception.
    /// </summary>
    /// <typeparam name="TType">The method return type.</typeparam>
    /// <typeparam name="TException">The type of exception that could be thrown. Must be of type <see cref="Exception"/></typeparam>
    public class Controlled<TType, TException>
        where TException: Exception
    {
        /// <summary>
        /// The return value of the method.
        /// </summary>
        public TType ReturnValue { get; set; } = default;

        /// <summary>
        /// The exception that was thrown.
        /// </summary>
        public TException Exception { get; set; } = null;
    }
}
