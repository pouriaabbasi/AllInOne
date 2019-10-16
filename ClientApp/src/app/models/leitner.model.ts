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

export class AddQuestionModel {
    boxId: number;
    meaning: string;
    vocabulary: string;
}

export class QuestionQueModel {
    stage: number;
    questions: QuestionModel[];
}

export class QuestionModel {
    boxId: number;
    createDate: Date;
    failCount: number;
    id: number;
    mainStage: number;
    meaning: string;
    subStage: number;
    vocabulary: string;
    isPending: boolean;
    isFinished: boolean;
}

export class ProcessQuestionModel {
    id: number;
    isSuccess: boolean;
}
