import { PaymentService } from "./PaymentService";
import { CustomerRepository } from "./CustomerRepository";
import { SmsService } from "./SmsService";
import { INotifyCustomerAboutOrder } from "./OrderNotifications/INotifyCustomerAboutOrder";

class PushNotificationService {
  push(deviceId: string, content: string) {
    console.log(`Pushing notification to device with id: ${deviceId}`);
  }
}

class Logger {
  log(message: string) {
    console.log(message);
  }
}

class ItemRepository {
  removeItems(items: any[]) {
    console.log("Removing items from database");
  }
}

class OrderHandler {
  paymentService: PaymentService;
  customerRepository: CustomerRepository;
  logger: Logger;
  itemRepository: ItemRepository;
  notificationServices: INotifyCustomerAboutOrder[];

  constructor(notificationServices: INotifyCustomerAboutOrder[]) {
    this.paymentService = new PaymentService();
    this.customerRepository = new CustomerRepository();
    this.logger = new Logger();
    this.itemRepository = new ItemRepository();
    this.notificationServices = notificationServices;
  }

  handle(items: any[], userId: string, creditCardInformation: any) {
    this.paymentService
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
var orderHandler = new OrderHandler(notificationServices);
var items = [];
var userId = "userId";
var creditCardInformation = {};
orderHandler.handle(items, userId, creditCardInformation);
