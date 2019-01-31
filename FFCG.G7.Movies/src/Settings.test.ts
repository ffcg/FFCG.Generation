import { Settings } from "./Settings";

describe('Settings', () => {
    let settings: Settings

    beforeEach(() => {
        settings = new Settings('settings.local.txt') 
    }) 

    it('should get connection string from local text file', () => {
        expect(settings.connectionString).toBe('database.txt') 
    })

    it('should get API address', () => {
        expect(settings.apiAddress).toBe('http://localhost:8081')
    })
})