<template>
    <row>
        <q-card
            width="block"
            class="q-card--admin-default"
            :title="systemConfigTexts.auditTitle">
            <q-row-container>
                <q-checkbox
                    v-model="model.RegistLoginOut"
                    :label="systemConfigTexts.auditLoginLabel" />
                <q-checkbox
                    v-model="model.RegistActions"
                    :label="systemConfigTexts.auditActionsLabel" />
                <q-checkbox
                    v-model="model.AuditInterface"
                    :label="systemConfigTexts.auditSystemLabel" />
                <q-checkbox
                    v-model="model.EventTracking"
                    :label="systemConfigTexts.eventTrackingLabel" />
            </q-row-container>
        </q-card>
    </row>
</template>

<script>
    import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import { SystemConfigTexts } from '@/resources/viewResources.ts';

    export default {
		name: 'audit',

        mixins: [reusableMixin],

		emits: ['alert-class'],

        props: {
			model: {
				required: true
			}
		},

		computed: {
			systemConfigTexts() {
				return new SystemConfigTexts(this)
			}
		}
    }
</script>
