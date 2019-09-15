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

export class AddItemModel {
    name: string;
    listId: number;
}

export class TodoMenu {
    groups: Array<TodoGroupModel>;
    lists: Array<TodoListModel>;
}

export class TodoGroupModel {
    name: string;
    lists: Array<TodoListModel>;
}

export class TodoListModel {
    id: number;
    name: string;
}
