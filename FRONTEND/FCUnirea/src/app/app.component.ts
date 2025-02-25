import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MainPageComponent } from "./pages/main-page/main-page.component";
import { ImagesServiceService } from './pages/main-page/services/images-service.service';
import { ImageSliderComponent } from "./pages/main-page/components/image-slider/image-slider.component";
import { Photo, SearchPhotosModel } from './pages/main-page/services/models/Photo';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MainPageComponent, ImageSliderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})

export class AppComponent implements OnInit {
  images: Photo[] = [];
  totalImages: number = 0;
  imagesIndex: number = 0;
  constructor(private imagesService: ImagesServiceService) {}
  ngOnInit(): void {
    this.imagesService.getImages().subscribe((res: SearchPhotosModel) => {
      this.images = res.photos;
      this.totalImages = res.per_page - 1;
    });
  }
}
