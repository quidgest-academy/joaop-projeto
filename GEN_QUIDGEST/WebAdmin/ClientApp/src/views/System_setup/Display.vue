<template>
	<div id="system_setup_settings_container">
		<row>
			<q-card
				class="q-card--admin-default"
				:title="systemConfigTexts.qualityAssuranceTitle"
				width="block">
				<q-checkbox
					v-model="model.QAEnvironment"
					:label="systemConfigTexts.qaEnvironmentLabel">
					<template #extras>
						<q-icon icon="information-outline" />
						{{ systemConfigTexts.qaEnvironmentInfo }}
					</template>
				</q-checkbox>
			</q-card>
		</row>

		<row>
			<q-card
				class="q-card--admin-default"
				:title="systemConfigTexts.dateFormatTitle"
				width="block">
				<q-row-container v-if="model.DateFormat">
					<q-text-field
						v-model="model.DateFormat.date"
						:label="hardcodedTexts.dataLabel"
						size="medium" />
					<q-text-field
						v-model="model.DateFormat.dateTime"
						:label="hardcodedTexts.dateTimeLabel"
						size="medium" />
					<q-text-field
						v-model="model.DateFormat.dateTimeSeconds"
						:label="hardcodedTexts.dateTimeSecondsLabel"
						size="large" />
					<q-text-field
						v-model="model.DateFormat.time"
						:label="hardcodedTexts.hoursLabel"
						size="small" />
				</q-row-container>
			</q-card>
		</row>

		<row>
			<q-card
				class="q-card--admin-default"
				:title="systemConfigTexts.numberFormatTitle"
				width="block">
				<q-row-container v-if="SelectLists">
					<q-select
						v-model="model.DecimalSeparator"
						:items="SelectLists.DecimalSeparator"
						item-value="Value"
						item-label="Text"
						:label="systemConfigTexts.decimalSeparatorLabel" />
					<q-select
						v-model="model.GroupSeparator"
						:items="SelectLists.GroupSeparator"
						item-value="Value"
						item-label="Text"
						:label="systemConfigTexts.groupSeparatorLabel" />
				</q-row-container>
			</q-card>
		</row>

		<row class="footer-btn">
			<q-button
				variant="bold"
				:label="hardcodedTexts.saveConfiguration"
				@click="saveConfigOthers" />
		</row>
	</div>
</template>

<script>
// @ is an alias to /src
import { reusableMixin } from '@/mixins/mainMixin';
import { QUtils } from '@/utils/mainUtils';
import { texts } from '@/resources/hardcodedTexts.ts';
import { SystemConfigTexts } from '@/resources/viewResources.ts';

export default {
	name: 'settings',

	props: {
		model: {
			required: true
		},
		SelectLists: {
			required: true
		}
	},

	mixins: [reusableMixin],

	emits: ['update-model', 'alert-class'],

	data() {
		var vm = this;
		return {
			modalForms: {
				core: {
					show: true,
					data: { }
				},
				advancedProperties: {
					show: false,
					data: { }
				},
			},
		};
	},
	computed: {
		hardcodedTexts() {
			return {
				dataLabel: this.Resources[texts.dataLabel],
				dateTimeLabel: this.Resources[texts.dateTimeLabel],
				dateTimeSecondsLabel: this.Resources[texts.dateTimeSecondsLabel],
				hoursLabel: this.Resources[texts.hoursLabel],
				saveConfiguration: this.Resources[texts.saveConfiguration],
				changesSavedSuccess: this.Resources[texts.changesSavedSuccess],
				languageLabel: this.Resources[texts.languageLabel]
			}
		},
		systemConfigTexts() {
			return new SystemConfigTexts(this)
		}
	},
	methods: {
		saveConfigOthers() {
			QUtils.log("SaveConfigOthers - Request", QUtils.apiActionURL('Config', 'SaveConfigOthers'));
			QUtils.postData('Config', 'SaveConfigOthers', this.model, null, (data) => {
				QUtils.log("SaveConfigOthers - Response", data);
				if (data.Success) {
					this.$emit('alert-class', { ResultMsg: this.hardcodedTexts.changesSavedSuccess, AlertType: 'success' });
				}
				else {
					this.$emit('alert-class', { ResultMsg: data.Message, AlertType: 'danger' });
				}
			});
		},
	},
	mounted() {
		this.tRepor.columns[0].label = this.systemConfigTexts.reportLabel
		this.tRepor.columns[1].label = this.hardcodedTexts.languageLabel
		this.tRepor.config.table_title = this.systemConfigTexts.reportsByLanguageTitle
	},
};
</script>
