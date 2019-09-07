export class ListModel {
    id: number;
    name: string;
    groupId: number;
    groupName: string;
    userId: number;
}

export class ItemModel {
    id: number;
    name: string;
    listId: number;
    listName: string;
    userId: number;
    completed: boolean;
    completedDate: Date;
    createDate: Date;
}
