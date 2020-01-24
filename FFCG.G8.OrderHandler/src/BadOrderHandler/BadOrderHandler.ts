class PaymentService {
  makePayment(items: any[], creditCardInformation: any): Promise<any> {
    console.log("Making payment");
    return Promise.resolve();
  }
}

class Customer {
  id: string;
  name: string;
  email: string;
  phoneNumber: string;
  deviceId: string;
}

class CustomerRepository {
  get(id: string): Promise<Customer> {
    var fakeCustomer = new Customer();
    fakeCustomer.id = "id";
    fakeCustomer.name = "Erik";
    fakeCustomer.email = "erik@forefront.se";
    fakeCustomer.phoneNumber = "0701020345";
    fakeCustomer.deviceId = "deviceId";
    return Promise.resolve(fakeCustomer);
  }
}

class EmailService {
  sendEmail(email: string, content: string) {
    console.log(`Sending an email to ${email}`);
  }
}

class SmsService {
  sendSms(phoneNumber: string, content: string, shippingInformation: any) {
    console.log(`Sending an SMS to ${phoneNumber}`);
  }
}

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
  emailService: EmailService;
  smsService: SmsService;
  pushNotificationService: PushNotificationService;
  logger: Logger;
  itemRepository: ItemRepository;

  constructor() {
    this.paymentService = new PaymentService();
    this.customerRepository = new CustomerRepository();
    this.emailService = new EmailService();
    this.smsService = new SmsService();
    this.pushNotificationService = new PushNotificationService();
    this.logger = new Logger();
    this.itemRepository = new ItemRepository();
  }

  handle(items: any[], userId: string, creditCardInformation: any) {
    this.paymentService
      .makePayment(items, creditCardInformation)
      .then(result => {
        this.customerRepository.get(userId).then(customer => {
          this.emailService.sendEmail(customer.email, "Grattis till köpet!");
          this.smsService.sendSms(
            customer.phoneNumber,
            "Grattis till köpet!",
            "Shipping information"
          );
          for (var i = 0; i < 10; i++) {
            this.pushNotificationService.push(
              customer.deviceId,
              "Grattis till köpet!"
            );
          }
          this.logger.log(`User ${userId} made a purchase`);
          this.itemRepository.removeItems(items);
        });
      });
  }
}

var orderHandler = new OrderHandler();
var items = [];
var userId = "userId";
var creditCardInformation = {};
orderHandler.handle(items, userId, creditCardInformation);
