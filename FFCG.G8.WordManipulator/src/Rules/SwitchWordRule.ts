import { ManipulateWordBaseRule } from "./ManipulateWordBaseRule";

export class SwitchWordRule extends ManipulateWordBaseRule {
    configs: ISwitchWordConfig[]

    constructor(configs: ISwitchWordConfig[]) {
        super(configs.map(x => x.old))
        this.configs = configs
    }

    manipulate(text: string, index?: number, array?: Array<any>) {
        const config: ISwitchWordConfig = (this.configs as ISwitchWordConfig[]).filter(x => x.old.toLocaleLowerCase() === text.toLowerCase())[0]

        if (config.previousWordStart && !array[index - 1].toLowerCase().startsWith(config.previousWordStart) || 
            config.previousWords && !this.previousWordsMatch(config, array, index))
            return text

        return config.new
    }

    private previousWordsMatch(config: ISwitchWordConfig, array: string[], index: number): boolean {
        for (var i = 1; i < config.previousWords.length; i++)
            if (array[index - i] !== config.previousWords[config.previousWords.length - i])
                return false

        return true
    }

}

export interface ISwitchWordConfig {
    old: string
    new: string
    previousWordStart?: string
    previousWords?: string[]
}