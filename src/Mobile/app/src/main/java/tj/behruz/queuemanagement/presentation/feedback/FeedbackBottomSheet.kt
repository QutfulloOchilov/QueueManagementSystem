package tj.behruz.queuemanagement.presentation.feedback

import android.app.Dialog
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.google.android.material.bottomsheet.BottomSheetBehavior
import com.google.android.material.bottomsheet.BottomSheetDialog
import com.google.android.material.bottomsheet.BottomSheetDialogFragment
import tj.behruz.queuemanagement.R
import tj.behruz.queuemanagement.databinding.FeedbackBottomSheetBinding
import tj.behruz.queuemanagement.presentation.extension.dp

class FeedbackBottomSheet() : BottomSheetDialogFragment() {
    private val binding by lazy(LazyThreadSafetyMode.NONE) {
        FeedbackBottomSheetBinding.inflate(layoutInflater)
    }

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ) = binding.root

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)
        val title = requireArguments().getString(TITLE, "")
        with(binding) {
            serviceName.text = title
        }
    }

    override fun getTheme(): Int = R.style.CustomBottomSheetDialog
    override fun onCreateDialog(savedInstanceState: Bundle?): Dialog {
        val dialog: Dialog = super.onCreateDialog(savedInstanceState)
        dialog.setOnShowListener { dialogInterface ->
            if (dialogInterface is BottomSheetDialog) {
                val modalBottomSheetBehavior = dialogInterface.behavior
                modalBottomSheetBehavior.halfExpandedRatio = 0.01f
                modalBottomSheetBehavior.expandedOffset = dp(30)
            }
        }
        return dialog
    }


    companion object {
        const val TAG = "FEEDBACK"
        const val TITLE = "title"
    }


}