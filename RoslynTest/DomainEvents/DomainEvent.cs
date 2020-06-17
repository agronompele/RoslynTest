using System;
using System.Reflection;

namespace RoslynTest.DomainEvents
{
    public abstract class DomainEvent
    {
        protected DomainEvent()
        {
            EventId = Guid.NewGuid();
        }

        public Guid EventId { get; }

        public object this[string propertyName]
        {
            get
            {
                Type eventType = GetType();

                PropertyInfo propertyInfo = eventType
                    .GetProperty(propertyName);

                if (propertyInfo == null)
                {
                    throw new MissingMemberException(eventType.Name, propertyName);
                }

                return propertyInfo.GetValue(this, null);
            }
        }
    }
}
