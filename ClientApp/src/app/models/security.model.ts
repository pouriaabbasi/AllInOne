export class UserModel {
    id: number;
    firstName: string;
    lastName: string;
    username: string;
    token: string;
}

export class RegisterModel {
    firstName: string;
    lastName: string;
    email: string;
    username: string;
    password: string;
    retypePassword: string;
}

export class LoginModel {
    username: string;
    password: string;
}
