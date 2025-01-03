import { Component, Inject, inject, Injector } from '@angular/core';
import { ListService } from './list.service';

@Component({
  selector: 'app-list',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styleUrl: './list.component.scss',
  providers:[ListService]
})
export class ListComponent {
  constructor(
    @Inject(ListService) public service: any,
) {}
  

  
  ngOnInit() {

    this.service.getAll();
  }

}
