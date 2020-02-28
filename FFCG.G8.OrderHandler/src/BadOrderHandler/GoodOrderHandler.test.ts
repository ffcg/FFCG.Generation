import { OrderHandler } from "./BadOrderHandler";
import { INotifyCustomerAboutOrder } from "./OrderNotifications/INotifyCustomerAboutOrder";
import { Customer } from "./CustomerRepository";
import { ILogger } from "./Logger";
import { IItemRepository } from "./ItemRepository";

describe("GoodOrderHandler", () => {
  let orderHandler: OrderHandler;
  let notificationServiceWasCalled: boolean;
  let fakeLogger: ILogger;
  let loggedMessage: string;
  let removedItemsWasCalled: boolean;

  beforeEach(() => {
    notificationServiceWasCalled = false;
    removedItemsWasCalled = false;
    //notify(customer: Customer, order: any): Promise<any>
    const fakeNotificationService: INotifyCustomerAboutOrder = {
      notify(customer: Customer, order: any) {
        notificationServiceWasCalled = true;
        return Promise.resolve({});
      }
    };
    const fakeLogger: ILogger = {
      log(message: string): string {
        loggedMessage = message;
        return message;
      }
    };
    const fakeItemRepository: IItemRepository = {
      addItems(items: any[]) {},
      removeItems(items: any[]) {
        removedItemsWasCalled = true;
      },
      getItems(): any[] {
        return [];
      }
    };
    const fakeNotificationServices: INotifyCustomerAboutOrder[] = [
      fakeNotificationService
    ];
    orderHandler = new OrderHandler(
      fakeNotificationServices,
      fakeLogger,
      fakeItemRepository
    );
  });

  it("when making a payment should notify customer", async () => {
    makePayment().then(x => {
      expect(notificationServiceWasCalled).toBe(true);
    });
  });

  it("when making a payment should log payment", done => {
    makePayment().then(x => {
      expect(loggedMessage).toBe(`User userId made a purchase`);
      done();
    });
  });

  it("when making a payment should remove items", done => {
    makePayment().then(x => {
      expect(removedItemsWasCalled).toBe(true);
      done();
    });
  });

  function makePayment() {
    const items = [];
    const userId = "userId";
    const creditCardInformation = {};
    return orderHandler.handle(items, userId, creditCardInformation);
  }
});
