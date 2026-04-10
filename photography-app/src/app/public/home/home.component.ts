import { Component, OnDestroy, OnInit } from '@angular/core';
import { PhotoRequestsService } from '../../../data/photo-requests.service';
import { PhotographerRequestsService } from '../../../data/photographer-requests.service';
import { DataStorageService } from '../../../data/data-storage.service';
import { CategoryRequestsService } from '../../../data/category-requests.service';

const NUMBER_CATEGORIES: number = 6;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit, OnDestroy{

  public gallery: any[];
  private photographerId: number;
  public categories: any[];
  public username: string;

  constructor(
    private photoRequests: PhotoRequestsService,
    private photographerRequest: PhotographerRequestsService,
    private categoryRequest: CategoryRequestsService,
    private dataStorage: DataStorageService) {
    this.gallery = [];
    this.categories = [];
    this.username = "";
    this.photographerId = dataStorage.getPhotographerId();
  }

  loadGallery() {
    for(let i = 0; i < 6; i++) {
      if(this.gallery[i].url === null) {
        this.gallery[i].url = this.dataStorage.getEmptyImageUrl();
      }
    }

  }

  getPhotographerInfo() {
     this.photographerRequest.getPhotographerInfo(this.photographerId).subscribe({
      next: (data: any) => {
        if(data !== null) {
          this.username = data.name + " " + data.materno;
        } else {
          console.error("photographer not found");
        }
      },
      error: (err) => {
        console.error('Error loading productos', err);
      }
    });
  }

  getGallery() {
    this.categoryRequest.getGallery(this.photographerId).subscribe({
      next: (data) => {
        if(data === null) {
          data = [];
        }
        this.gallery = data;
        this.loadGallery();
      },
      error: () => {
        console.error("error while retrieving photos");
      }
    });
  }

  public ngOnInit(): void {
    this.getPhotographerInfo();
    this.getGallery();
  }

  public ngOnDestroy(): void {
    
  }

}
