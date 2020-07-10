import cv2
import numpy as np
import pytesseract

# pytesseract.pytesseract.tesseract_cmd = "C:\\Program Files\\Tesseract-OCR\\tesseract.exe"
image_path = "car_images/2.jpg"

image = cv2.imread(image_path)
gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)

# cv2.imshow("Gray", gray)
# cv2.waitKey(0)

blur = cv2.bilateralFilter(gray, 11, 90, 90)

# cv2.imshow("Blur", blur)
# cv2.waitKey(0)

edges = cv2.Canny(blur, 30, 200)

# cv2.imshow("Edges", edges)
# cv2.waitKey(0)

cnts, new = cv2.findContours(edges.copy(), cv2.RETR_LIST, cv2.CHAIN_APPROX_SIMPLE)

image_copy = image.copy()
_ = cv2.drawContours(image_copy, cnts, -1, (255, 0, 255), 2)

# cv2.imshow("Contours", image_copy)
# cv2.waitKey(0)

# bierzemy najdluzsze 30 kontur
cnts = sorted(cnts, key=cv2.contourArea, reverse=True)[:30]

image_copy = image.copy()
_ = cv2.drawContours(image_copy, cnts, -1, (255, 0, 255), 2)

# cv2.imshow("Top 30 Contours", image_copy)
# cv2.waitKey(0)

plate = None
for c in cnts:
    #epsilon definiuje dokladnosc rysowania zamkietych kontur
    epsilon = 0.02 * cv2.arcLength(c, True)
    #obliczenie dlugosci krawedzi
    edges_count = cv2.approxPolyDP(c, epsilon, True)
    if len(edges_count) == 4:
        x, y, w, h = cv2.boundingRect(c)
        plate = image[y:y + h, x:x + w]
        break

cv2.imwrite("plate.png", plate)
cv2.imshow("ss", plate)
cv2.waitKey(0)



