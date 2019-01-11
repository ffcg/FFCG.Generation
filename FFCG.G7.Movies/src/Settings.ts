import { readFileSync } from "fs";

export class Settings {
    connectionString: string

    constructor(configName: string) {
        this.connectionString = readFileSync(configName).toString().split(' ')[1]
    }
}