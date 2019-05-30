import { Position } from './Position';

export class RegisterRequest {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  position: Position;
}
