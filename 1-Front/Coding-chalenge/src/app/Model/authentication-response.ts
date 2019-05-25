import { User } from './user';

export class AuthenticationResponse{
    message :string
    isSuccess :boolean
    user :User
}