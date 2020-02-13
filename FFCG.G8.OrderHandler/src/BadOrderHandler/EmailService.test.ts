import { EmailService } from "./EmailService";

describe("Email Service", () => {
  let emailService: EmailService;

  beforeEach(() => {
    emailService = new EmailService();
  });

  it("sendEmail should send email", done => {
    const expectedResponse = "Sent email";
    emailService.sendEmail("email@provider.com", "content").then(response => {
      expect(response).toBe(expectedResponse);
      done();
    });
  });
});
