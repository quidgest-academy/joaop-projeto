﻿<template>
	<div id="system_setup_external_services_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="systemConfigTexts.integrationSettingsAI"
				width="block">
				<q-row-container>
					<q-text-field
						v-model="model.UrlAPIBackend"
						:label="systemConfigTexts.urlAPIBackendLabel">
						<template #extras>
							<div class="q-field__extras">
								<q-icon icon="information-outline" />
								{{ systemConfigTexts.urlAPIBackendInfo }}
							</div>
						</template>
					</q-text-field>
				</q-row-container>
			</q-card>
		</row>
		<elasticsearch
            :model="model"
			:Cores="Cores"
			:SelectLists="SelectLists"
            @alert-class="forwardAlert" />
        <reports
            :model="model"
            @alert-class="forwardAlert" />
		<row class="footer-btn">
			<q-button
				variant="bold"
				:label="systemConfigTexts.saveConfigurationButton"
				@click="saveConfigOthers" />
		</row>
	</div>
</template>

<script>
	// @ is an alias to /src
	import { reusableMixin } from '@/mixins/mainMixin';
	import { QUtils } from '@/utils/mainUtils';
	import elasticsearch from './Elasticsearch';
	import reports from './Reports';
	import { SystemConfigTexts } from '@/resources/viewResources.ts';
	import { texts } from '@/resources/hardcodedTexts.ts';

	export default {
		name: 'externalservices',
		components: { elasticsearch, reports },
		props: {
			model: {
				required: true
			},
			Cores: {
				required: true
			},
			SelectLists: {
				required: true
			}
		},

		mixins: [reusableMixin],

		emits: ['update-model', 'alert-class'],

		computed: {
			systemConfigTexts() {
				return new SystemConfigTexts(this)
			},

			hardcodedTexts() {
				return {
					changesSavedSuccess: this.Resources[texts.changesSavedSuccess]
				}
			}
		},

		methods: {
			saveConfigOthers() {
				QUtils.log("SaveConfigOthers - Request", QUtils.apiActionURL('Config', 'SaveConfigOthers'));
				QUtils.postData('Config', 'SaveConfigOthers', this.model, null, (data) => {
					QUtils.log("SaveConfigOthers - Response", data);
						this.$emit('alert-class', {
						ResultMsg: data.Success ? this.hardcodedTexts.changesSavedSuccess : data.Message,
						AlertType: data.Success ? 'success' : 'danger'
					});
				});
			},
		}
	};
</script>
