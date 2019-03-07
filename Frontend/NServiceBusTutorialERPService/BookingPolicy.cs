using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBusTutorialMessages;

namespace NServiceBusTutorialERPService
{
    public class BookingPolicy : Saga<BookingPolicyData>, IAmStartedByMessages<OrderPlacedEvent>, IAmStartedByMessages<PaymentPlacedEvent>, IAmStartedByMessages<DecreePlacedEvent>, IAmStartedByMessages<InvoicePlacedEvent>
    {
        static ILog log = LogManager.GetLogger<OrderPlacedEvent>();


        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<BookingPolicyData> mapper)
        {
           mapper.ConfigureMapping<OrderPlacedEvent>(m => m.OrderId).ToSaga(m => m.OrderId);
           mapper.ConfigureMapping<PaymentPlacedEvent>(m => m.OrderId).ToSaga(m => m.OrderId);
           mapper.ConfigureMapping<DecreePlacedEvent>(m => m.OrderId).ToSaga(m => m.OrderId);
           mapper.ConfigureMapping<InvoicePlacedEvent>(m => m.OrderId).ToSaga(m => m.OrderId);
        }

        public Task Handle(OrderPlacedEvent message, IMessageHandlerContext context)
        {
            log.Info("OrderPlaced " + Data.OrderId);
            Data.IsOrderPlaced = true;
            ProcessDocument(context);
            return Task.CompletedTask;
        }

        public Task Handle(PaymentPlacedEvent message, IMessageHandlerContext context)
        {
            log.Info("PaymentPlaced " + Data.OrderId);
            Data.IsPaymentPlaced = true;
            ProcessDocument(context);
            return Task.CompletedTask;
        }

        public Task Handle(DecreePlacedEvent message, IMessageHandlerContext context)
        {
            log.Info("DecreePlaced " + Data.OrderId);
            Data.IsDecreePlaced = true;
            ProcessDocument(context);
            return Task.CompletedTask;
        }

        public Task Handle(InvoicePlacedEvent message, IMessageHandlerContext context)
        {
            log.Info("InvoicePlaced " + Data.OrderId);
            Data.IsInvoicePlaced = true;
            ProcessDocument(context);
            return Task.CompletedTask;
        }

        public void ProcessDocument(IMessageHandlerContext context)
        {
            if (Data.IsDecreePlaced && Data.IsInvoicePlaced && Data.IsOrderPlaced && Data.IsPaymentPlaced)
            {
                log.Info("Ship this order now!! " + Data.OrderId);
                MarkAsComplete();
            }
        }
    }

    public class BookingPolicyData : ContainSagaData
    {
        public bool IsOrderPlaced { get; set; }
        public bool IsInvoicePlaced { get; set; }
        public bool IsPaymentPlaced { get; set; }
        public bool IsDecreePlaced { get; set; }

        public string OrderId { get; set; }
    }
}
