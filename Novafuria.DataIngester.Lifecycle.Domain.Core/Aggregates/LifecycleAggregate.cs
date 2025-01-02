using Novafuria.DataIngester.Domain.Core.DomainEvents.Abstractions;
using Novafuria.DataIngester.Lifecycle.Domain.Core.DomainEvents;

namespace Novafuria.DataIngester.Lifecycle.Domain.Core.Aggregates
{
    public class LifecycleAggregate
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public bool IsInitialized { get; private set; }

        private List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public LifecycleAggregate()
        {
            // Por defecto no inicializado.
            IsInitialized = false;
        }

        public void Initialize()
        {
            if (IsInitialized)
            {
                // Ya está inicializado, no hacer nada, o lanzar una excepción si corresponde.
                return;
            }

            // Lógica de inicialización interna: podría preparar estados internos,
            // validar condiciones, etc.

            IsInitialized = true;

            // Generar evento de dominio
            var @event = new DomainInitializedDomainEvent();
            _domainEvents.Add(@event);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
