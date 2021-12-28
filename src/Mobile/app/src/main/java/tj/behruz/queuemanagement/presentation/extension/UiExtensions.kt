package tj.behruz.queuemanagement.presentation.extension

import android.content.Context
import android.os.Bundle
import android.util.TypedValue
import androidx.appcompat.app.AppCompatActivity
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import kotlin.math.roundToInt

fun Fragment.navigateToScreen(action: Int, bundle: Bundle? = null) {
    findNavController().navigate(action, bundle)
}

fun Fragment.hideActionbar() {
    (activity as AppCompatActivity).supportActionBar.apply {
        this?.hide()
    }
}

fun Fragment.showActionbar(title: String? = null) {
    (activity as AppCompatActivity).supportActionBar.apply {
        this?.show()
        if (title != null) {
            this?.title = title
        }
    }
}

fun Context.dp(px: Int): Int {
    return TypedValue.applyDimension(TypedValue.COMPLEX_UNIT_DIP, px.toFloat(), resources.displayMetrics).roundToInt()
}

fun Fragment.dp(px: Int): Int = requireContext().dp(px)