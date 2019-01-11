import { Settings } from "./Settings";

describe('Settings', () => {
    let settings: Settings

    it('should get connection string from local text file', () => {
        const settings = new Settings('settings.local.txt')
        expect(settings.connectionString).toBe('database.txt')
    })
})