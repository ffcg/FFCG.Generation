import { TextManipulator } from "./TextManipulator";
import { CapitalizeRule } from "./Rules/CapitalizeRule";
import { ReverseRule } from "./Rules/ReverseRule";
import { SwitchPositionRule } from "./Rules/SwitchPositionRule";
import { SwitchWordRule } from "./Rules/SwitchWordRule";
import { ConcatenationRule } from "./Rules/ConcatenationRule";

describe("TextManipulator", function() {
  let manipulator: TextManipulator;

  it("should manipulate text", () => {
    const rules = [
      new CapitalizeRule(["om", "king", "frontiers"]),
      new ReverseRule(["remmok", "räh"]),
      new SwitchPositionRule(["eernatrain", "ortgj", "nnasta"]),
      new SwitchWordRule([
        { old: "företaget", new: "Forefront" },
        { old: "inget", new: "allt" },
        { old: "äppelkaka", new: "motstånd" },
        { old: "förpestas", new: "förgyllas" }
      ])
    ];
    manipulator = new TextManipulator(rules);

    expect(manipulator.manipulate(getScrambledText())).toBe(getOriginaltext());
  });

  it("should manipulate new text", () => {
    const rules = [
      new CapitalizeRule(["om", "king", "frontiers"]),
      new ReverseRule(["remmok", "räh"]),
      new SwitchPositionRule(["eernatrain", "ortgj", "nnasta"]),
      new SwitchWordRule([
        { old: "företaget", new: "Forefront" },
        { old: "inget", new: "allt" },
        { old: "äppelkaka", new: "motstånd" },
        { old: "förpestas", new: "förgyllas" },
        { old: "av", new: "från", previousWordStart: "s" },
        {
          old: "king",
          new: "Queen",
          previousWords: ["Code", "is"]
        }
      ]),
      new ConcatenationRule(["regel rätta", "kod ninjor"])
    ];

    manipulator = new TextManipulator(rules);

    expect(manipulator.manipulate(getNewScrambledText())).toBe(
      getNewOriginalText()
    );
  });

  function getScrambledText() {
    return "Företaget är räh för att nnasta. Med stöd av alla frontiers remmok eernatrain mosa inget äppelkaka. om två år remmok företaget förpestas när eernatrain ortgj klart utbildningen Code is king!";
  }

  function getOriginaltext() {
    return "Forefront är här för att stanna. Med stöd av alla Frontiers kommer traineerna mosa allt motstånd. Om två år kommer Forefront förgyllas när traineerna gjort klart utbildningen Code is King!";
  }

  function getNewScrambledText() {
    return (
      getScrambledText() +
      " " +
      "Då remmok de bli regel rätta kod ninjor av rang. King börjar inte ens beskriva hur grymma de blir."
    );
  }

  function getNewOriginalText() {
    return (
      "Forefront är här för att stanna. Med stöd från alla Frontiers kommer traineerna mosa allt motstånd. Om två år kommer Forefront förgyllas när traineerna gjort klart utbildningen Code is Queen!" +
      " " +
      "Då kommer de bli regelrätta kodninjor av rang. King börjar inte ens beskriva hur grymma de blir."
    );
  }
});
