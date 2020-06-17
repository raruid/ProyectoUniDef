import { Component, Injector, Inject, OnInit, Optional } from '@angular/core';
import {
    MatDialogRef,
    MAT_DIALOG_DATA,
    MatCheckboxChange
} from '@angular/material';
import { finalize } from 'rxjs/operators';
import * as _ from 'lodash';
import { AppComponentBase } from '@shared/app-component-base';
import { EventosServiceProxy, GetEventoForEditOutput, EventoDto} from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: 'edit-evento-dialog.component.html',
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
export class EditEventoDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    evento: EventoDto = new EventoDto();
  
    constructor(
        injector: Injector,
        private _eventoService: EventosServiceProxy,
        private _dialogRef: MatDialogRef<EditEventoDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
        this.evento.id = _id;
    }

    ngOnInit(): void {
        this._eventoService
            .getEventoForEdit(this._id)
            .subscribe(result => {
                this.evento.name = result.name;
                //this.evento.
            });
                
                //this.grantedPermissionNames = result.grantedPermissionNames;
                //this.setInitialPermissionsStatus();
            
    }

    
    
     save(): void {
        this.saving = true;
        this._eventoService
            .update(this.evento)
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
