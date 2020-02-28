import { PaymentService } from "./PaymentService";
import { CustomerRepository } from "./CustomerRepository";
import { SmsService } from "./SmsService";
import { INotifyCustomerAboutOrder } from "./OrderNotifications/INotifyCustomerAboutOrder";
import { ILogger, Logger } from "./Logger";
import { IItemRepository, ItemRepository } from "./ItemRepository";

class PushNotificationService {
  push(deviceId: string, content: string) {
    console.log(`Pushing notification to device with id: ${deviceId}`);
  }
}

export class OrderHandler {
  paymentService: PaymentService;
  customerRepository: CustomerRepository;
  logger: Logger;
  itemRepository: IItemRepository;
  notificationServices: INotifyCustomerAboutOrder[];

  constructor(
    notificationServices: INotifyCustomerAboutOrder[],
    logger: ILogger,
    itemRepository: IItemRepository
  ) {
    this.paymentService = new PaymentService();
    this.customerRepository = new CustomerRepository();
    this.logger = logger;
    this.itemRepository = itemRepository;
    this.notificationServices = notificationServices;
  }

  handle(
    items: any[],
    userId: string,
    creditCardInformation: any
  ): Promise<any> {
    return this.paymentService
      .makePayment(items, creditCardInformation)
      .then(result => {
        this.customerRepository.get(userId).then(customer => {
          for (var i = 0; i < this.notificationServices.length; i++)
            this.notificationServices[i].notify(customer, {});

          this.logger.log(`User ${userId} made a purchase`);
          this.itemRepository.removeItems(items);
        });
      });
  }
}

var notificationServices: INotifyCustomerAboutOrder[] = [new SmsService()];
const logger = new Logger();
const itemRepository = new ItemRepository();
var orderHandler = new OrderHandler(
  notificationServices,
  logger,
  itemRepository
);
var items = [];
var userId = "userId";
var creditCardInformation = {};
orderHandler.handle(items, userId, creditCardInformation);
