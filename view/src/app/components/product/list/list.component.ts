import { Component, OnInit } from '@angular/core';
import { ProductService } from '../Product.service'

// PaginationDTO in TypeScript
export interface PaginationDTO {
  pageNo: number;
  size: number;
  search: string;
  sortBy: string;
  sortDirection: string;
  isPagination: boolean;
}

// ProductFilterDTO extends PaginationDTO
export interface ProductFilterDTO extends PaginationDTO {
  id: number;
}


@Component({
  selector: 'app-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  products: any[] = [];
  filter: ProductFilterDTO = {
    id: 0, // This can be any value or dynamic based on your use case
    pageNo: 1,
    size: 10,
    search: '',
    sortBy: 'name',
    sortDirection: 'asc',
    isPagination: true
  };
  constructor(private ProductService: ProductService) {

  }

  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts(): void {
    this.ProductService.getDataById(this.filter).subscribe((data) => {
      this.products = data;
    });
  }
}
