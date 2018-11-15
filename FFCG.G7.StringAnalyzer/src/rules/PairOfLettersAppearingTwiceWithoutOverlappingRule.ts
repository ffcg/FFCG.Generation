import { IRule } from "./IRule";

export class PairOfLettersAppearingTwiceWithoutOverlappingRule implements IRule {
    isNice(word: string) {
        const toPairs = (c, i, a) => c + a[i+1]
        const nonConsecutive = (p, i, a) => p !== a[i+1] || p === a[i-1] && p === a[i+1]
        const pairs = word.split('').map(toPairs).filter(nonConsecutive)
        
        function onUnique(value, index, self) { 
            return self.indexOf(value) === index;
        }

        return pairs.filter(onUnique).length < pairs.length;
    }
}
