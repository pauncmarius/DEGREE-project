import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Photo, SearchPhotosModel } from './models/Photo';

@Injectable({
  providedIn: 'root',
})
export class ImagesServiceService {
  // Define your local photos using a single URL property.
  private photos: Photo[] = [
    { id: 1, url: 'assets/stadiums/1.jpg' },
    { id: 2, url: 'assets/stadiums/2.jpg' },
    { id: 3, url: 'assets/stadiums/3.jpg' },
    { id: 4, url: 'assets/stadiums/4.jpg' },
    { id: 5, url: 'assets/stadiums/5.jpg' },
    { id: 6, url: 'assets/stadiums/6.jpg' },
    { id: 7, url: 'assets/stadiums/7.jpg' },
    { id: 8, url: 'assets/stadiums/8.jpg' },
    { id: 9, url: 'assets/stadiums/9.jpg' },
  ];

  constructor() {}

  getImages(): Observable<SearchPhotosModel> {
    // Create a local response that mimics the API response structure.
    const localResponse: SearchPhotosModel = {
      page: 1,
      per_page: this.photos.length,
      photos: this.photos,
      total_results: this.photos.length,
      next_page: '' // or null if not applicable
    };
    return of(localResponse);
  }
}
