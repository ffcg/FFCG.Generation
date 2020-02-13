import { SmsService } from "./SmsService";

describe("SMS Service", () => {
  let smsService: SmsService;

  beforeEach(() => {
    smsService = new SmsService();
  });

  it("sendSMS should send SMS", done => {
    const phoneNumber = "0701020345";
    const content = "content";
    const shippingInformation = {};
    const expectedResponse = "Sent SMS";
    smsService
      .sendSms(phoneNumber, content, shippingInformation)
      .then(response => {
        expect(response).toBe(expectedResponse);
        done();
      });
  });
});
