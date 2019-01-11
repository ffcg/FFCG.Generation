import { IHttpClient } from "./IHttpClient";

export class HttpClient implements IHttpClient {
    get(url: string): Promise<string> {
        return Promise.resolve('')
        //make real API call against movie DB
    }
}