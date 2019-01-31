import { readFileSync } from "fs";

export class Settings {
    connectionString: string
    apiAddress: string
    apiPort: number

    constructor(configName: string) {
        const config = JSON.parse(readFileSync(configName).toString())
        this.connectionString = config.connectionString
        this.apiAddress = config.apiBaseAddress + ':' + config.apiPort
        this.apiPort = config.apiPort
    }
}