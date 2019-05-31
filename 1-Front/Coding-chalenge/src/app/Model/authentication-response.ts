import { User } from "./user";
/**
 * authentication response
 *
 */
export class AuthenticationResponse {
  message: string;
  isSuccess: boolean;
  user: User;
}
