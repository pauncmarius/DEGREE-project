export interface Seat {
  id: number;
  seatName: string;
  seatPrice: number;
  seatType: string;
  seat_StadiumsId: number;
  isTaken?: boolean;
  stadiumName?: string; // ✅ corect, nu seat_StadiumName
}
