export interface Photo {
  id: number;
  url: string;
}

export interface SearchPhotosModel {
  page: number;
  per_page: number;
  photos: Photo[];
  total_results: number;
  next_page?: string;
}
