import { Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DataStorageService {

  private photographerId: number = 2; // IF YOU WANT TO USE ANOTHER PHOTOGRAPHER CHANGE THE ID HERE
  private emptyImageUrl: string = "assets/emptyImage.jpg";

  constructor(private route: ActivatedRoute) {
  }

  getPhotographerId() {
    return this.photographerId;
  }

  getEmptyImageUrl() {
    return this.emptyImageUrl;
  }
}
