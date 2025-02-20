import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestService } from './services/test.service';
import { Photo } from './services/models/PhotoModel';
import { SearchPhotosModel } from './services/models';
import { DirectionalButtonComponent } from "./components/directional-button/directional-button.component";

@Component({
  selector: 'app-main-page',
  standalone: true, // Adăugat pentru a permite importul direct
  imports: [CommonModule, DirectionalButtonComponent], // Importă CommonModule pentru a avea acces la directivele Angular
  templateUrl: './main-page.component.html',
  styleUrl: './main-page.component.scss',
})
export class MainPageComponent implements OnInit {
  constructor(private testService: TestService) {}

  images: Photo[] = [];
  totalImages: number = 0;
  index: number = 0;

  ngOnInit(): void {
    this.testService.getImages().subscribe((res: SearchPhotosModel) => {
      this.totalImages = res.total_results;
      this.images = res.photos;
    });
  }
  PrevButton() {
      if (this.index - 1 == -1) {
        this.index = this.totalImages - 1;
      } else {
        this.index = this.index - 1;
      }
  };
  NextButton() {
      if (this.index + 1 == this.totalImages) {
        this.index = 0;
      } else {
        this.index = this.index + 1;
      }
  };
  onChangeIndex(newIndex: any){
    debugger;
    this.index = newIndex;
  }
}
