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
        where TException : Exception
    {
        /// <summary>
        /// The return value of the method.
        /// </summary>
        public TType ReturnValue { get; set; } = default;

        /// <summary>
        /// The exception that was thrown.
        /// </summary>
        public TException Exception { get; set; } = null;

        /// <summary>
        /// Returns the current <see cref="ReturnValue"/> safely, ignoring all exceptions.
        /// Returns <see cref="default(TType)"/> if any exception is thrown.
        /// </summary>
        public TType SafeValue
        {
            get
            {
                try { return ReturnValue; }
                catch { return default; }
            }
        }

        /// <summary>
        /// Did the current <see cref="Controlled{TType, TException}"/> method threw an exception?
        /// </summary>
        public bool HasException => Exception != null;

        /// <summary>
        /// Stringifies the current exception.
        /// </summary>
        public string ExceptionAsString => $"{Exception.GetType()}: {Exception.Message}";

        public override string ToString()
            => $"Value: {ReturnValue}; "+
                (Exception ==null ? "No exception was thrown." : $"{Exception.GetType()}: {Exception.Message}");


    }
}
