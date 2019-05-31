import { Position } from "./Position";

/**
 * registration request
 *
 */
export class RegisterRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  position: Position;
}
