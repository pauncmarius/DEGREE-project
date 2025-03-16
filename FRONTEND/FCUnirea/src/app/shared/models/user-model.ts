export interface User {
  id: string | null;
  username: string;
  email: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  hashedPassword: string;
  role: string;
}

