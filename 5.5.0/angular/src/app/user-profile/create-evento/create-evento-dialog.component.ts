import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef, MatCheckboxChange } from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import {EventosServiceProxy, EventoDto, CreateEventoDto,
   
} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'create-evento-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class CreateEventoDialogComponent extends AppComponentBase  {
    saving = false;
    evento: CreateEventoDto = new CreateEventoDto();
      

    constructor(
        injector: Injector,
        private _eventoService: EventosServiceProxy,
        private _dialogRef: MatDialogRef<CreateEventoDialogComponent>
    ) {
        super(injector);
    }

  
    
    save(): void {
        this.saving = true;
        const evento_ = new CreateEventoDto();
        evento_.init(this.evento);
        console.log(evento_);

        this._eventoService
            .createEvento(evento_)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
