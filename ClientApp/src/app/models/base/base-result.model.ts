export class BaseResultModel<T> {
    type: string;
    message: string;
    data: T;
}
