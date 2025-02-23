import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SearchPhotosModel } from './models';

@Injectable({
  providedIn: 'root',
})
export class ImagesServiceService {
  private API_KEY = '563492ad6f917000010000015078eb39ced74eb4be75cbef5cad38ff';

  constructor(private httpClient: HttpClient) {}

  getImages(): Observable<SearchPhotosModel> {
    const url = 'https://api.pexels.com/v1/curated?per_page=25';
    const options = {
      headers: new HttpHeaders({
        Authorization: this.API_KEY,
      }),
    };
    return this.httpClient.get<SearchPhotosModel>(url, options);
  }
}
