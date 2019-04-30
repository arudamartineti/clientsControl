import { IRole } from "./role";

export interface IUser {
  id: string,
  userName: string,
  email: string,
  password: string,
  fullName: string,
  clientUser: boolean,
  clientReup: string,
  authorized: boolean,
  roles: string[]
}
