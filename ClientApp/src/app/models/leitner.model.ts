export class LeitnerBoxModel {
    id: number;
    name: string;
    description: string;
}

export class LeitnerBoxStatisticsModel {
    boxName: string;
    allQuestionCount: number;
    readyForTestCount: number;
    compeletedQuestionCount: number;
    failCount: number;
    labels: string[];
    counts: number[];
}

export class QuestionModel {
    id: number;
    boxId: number;
    meaning: string;
    vocabulary: string;
}
