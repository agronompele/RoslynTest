using System;
using System.Reflection;
using System.Text;

namespace RoslynTest.Commands
{
    public abstract class Command
    {
        protected Command()
        {
            Id = Guid.NewGuid();
        }
        
        public Guid Id { get; }

        public object this[string propertyName]
        {
            set
            {
                Type commandType = GetType();

                PropertyInfo propertyInfo = commandType
                    .GetProperty(propertyName);

                if (propertyInfo == null)
                {
                    throw new MissingMemberException(commandType.Name, propertyName);
                }

                try
                {
                    propertyInfo.SetValue(this, value, null);
                }
                catch (ArgumentException exception)
                {
                    var exceptionMessageBuilder = new StringBuilder();

                    exceptionMessageBuilder.Append(
                        $"Can't set value '{value}' to {propertyName} of {commandType.Name} Command.");

                    exceptionMessageBuilder.AppendLine();
                    exceptionMessageBuilder.Append(exception.Message);

                    throw new ArgumentException(exceptionMessageBuilder.ToString(), exception.ParamName);
                }
            }
        }
    }
}
